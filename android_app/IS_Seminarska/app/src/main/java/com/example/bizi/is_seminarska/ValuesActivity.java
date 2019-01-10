package com.example.bizi.is_seminarska;

import android.app.ActionBar;
import android.content.Intent;
import android.support.constraint.ConstraintLayout;
import android.support.constraint.ConstraintSet;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.ViewGroup;
import android.view.ViewManager;
import android.widget.LinearLayout;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class ValuesActivity extends AppCompatActivity {
    TableLayout tableLayout;
    TextView roomName;
    TextView evalView;
    LinearLayout valueLinear;
    JSONArray senzorji;
    @Override
    protected void onStart() {
        super.onStart();
        for(int i = 0; i < tableLayout.getChildCount(); i++){
            ((ViewManager)tableLayout).removeView(tableLayout.getChildAt(i));
        }
        for(int i = 0; i < valueLinear.getChildCount(); i++){
            ((ViewManager)valueLinear).removeView(valueLinear.getChildAt(i));
        }
        Intent intent = getIntent();
        roomName.setText(intent.getStringExtra("imeSobe"));
        try {
            senzorji = new JSONArray(intent.getStringExtra("senzorji"));
            output();

        }
        catch(JSONException e){
            Log.e("Volley", "Invalid JSONObject");
        }

    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_values);
        ConstraintLayout constraintLayout = (ConstraintLayout)findViewById(R.id.valueConstraint);
        roomName = findViewById(R.id.imeSobe);
        ConstraintLayout.LayoutParams params = new ConstraintLayout.LayoutParams(
                ViewGroup.LayoutParams.WRAP_CONTENT,
                ViewGroup.LayoutParams.WRAP_CONTENT
        );
        params.setMargins(8, 8, 8, 8);
        roomName.setLayoutParams(params);
        evalView = (TextView)findViewById(R.id.valueText);
        tableLayout = findViewById(R.id.valueTable);
        params = new ConstraintLayout.LayoutParams(ActionBar.LayoutParams.WRAP_CONTENT, ViewGroup.LayoutParams.WRAP_CONTENT);
        params.setMargins(8, 8, 8, 8);
        tableLayout.setLayoutParams(params);
        valueLinear = findViewById(R.id.valueLinear);
        ConstraintSet constraintSet = new ConstraintSet();
        constraintSet.clone(constraintLayout);
        constraintSet.connect(roomName.getId(), ConstraintSet.TOP, constraintLayout.getId(), ConstraintSet.TOP, 8);
        constraintSet.connect(roomName.getId(), ConstraintSet.LEFT, constraintLayout.getId(), ConstraintSet.LEFT, 8);
        constraintSet.connect(tableLayout.getId(), ConstraintSet.TOP, roomName.getId(), ConstraintSet.BOTTOM);
        constraintSet.connect(tableLayout.getId(), ConstraintSet.LEFT, constraintLayout.getId(), ConstraintSet.LEFT, 8);
        constraintSet.connect(tableLayout.getId(), ConstraintSet.BOTTOM, valueLinear.getId(), ConstraintSet.TOP, 8);
        constraintSet.connect(valueLinear.getId(), ConstraintSet.LEFT, constraintLayout.getId(), ConstraintSet.LEFT, 8);
        constraintSet.connect(valueLinear.getId(), ConstraintSet.BOTTOM, constraintLayout.getId(), ConstraintSet.BOTTOM, 8);
        constraintSet.applyTo(constraintLayout);

        /*tableLayout.setLayoutParams(new ConstraintLayout.LayoutParams(
                ViewGroup.LayoutParams.MATCH_PARENT,
                ViewGroup.LayoutParams.WRAP_CONTENT
        ));*/


    }

    private void output(){
        TableRow tableRow;
        LinearLayout linearLayout;
        TextView textView;
        JSONObject senzor;
        String viewText;
        String sensType;
        StringBuilder evalStr = new StringBuilder("");
        int sensVal;
        for(int i = 0; i < senzorji.length(); i++){
            try{
                senzor = senzorji.getJSONObject(i);
                textView = new TextView(this);
                textView.setLayoutParams(new ConstraintLayout.LayoutParams(
                        ViewGroup.LayoutParams.MATCH_PARENT,
                        ViewGroup.LayoutParams.WRAP_CONTENT
                ));
                sensType = senzor.getJSONObject("senzor").getString("imeSenzorja");
                sensVal = senzor.getInt("vrednostSenzorja");
                viewText = sensType + ": " + String.valueOf(sensVal);
                switch(sensType){
                    case "termometer":
                        viewText += "°C";
                        if(sensVal < 19){
                            evalStr.append("V Sobi je hladno \n");
                        }
                        else if(sensVal >= 19 && sensVal < 24){
                            evalStr.append("V sobi je prijetno \n");
                        }
                        else if(sensVal >= 24){
                            evalStr.append("V sobi je vroče\n");
                        }
                        break;

                    case "photoresistor":
                        if(sensVal < 40){
                            evalStr.append("V sobi temno \n");
                        }
                        else if(sensVal >= 40 ){
                            evalStr.append("V sobi je svetlo \n");
                        }

                        break;
                    case "vlaga":
                        viewText += "%";
                        if(sensVal < 30){
                            evalStr.append("V sobi je zelo suh zrak \n");
                        }
                        else if(sensVal >= 30 && sensVal < 65){
                            evalStr.append("V sobi je prijetna vlaga \n");
                        }
                        else {
                            evalStr.append("V sobi je prevelažno\n");
                        }
                        break;
                    case "IR sensor":
                        if(sensVal == 1){
                            evalStr.append("V sobi je nekdo \n");
                        }
                        else {
                            evalStr.append("V sobi ni nikogar\n");
                        }
                        break;

                }
                textView.setText(viewText);
                linearLayout = new LinearLayout(this);
                linearLayout.setLayoutParams(new TableRow.LayoutParams(
                        ViewGroup.LayoutParams.MATCH_PARENT,
                        ActionBar.LayoutParams.WRAP_CONTENT
                ));
                linearLayout.addView(textView);

                tableRow = new TableRow(this);
                tableRow.setLayoutParams(new TableLayout.LayoutParams(
                        ViewGroup.LayoutParams.MATCH_PARENT,
                        ViewGroup.LayoutParams.WRAP_CONTENT
                ));
                tableRow.addView(linearLayout);
                tableLayout.addView((tableRow));
            }

            catch(JSONException e){
                Log.e("Volley", "Invalid JSONObject");
            }
        }
        evalStr.trimToSize();
        String a = evalStr.toString();
        evalView.setText(a);
        valueLinear.addView(evalView);
    }
}
