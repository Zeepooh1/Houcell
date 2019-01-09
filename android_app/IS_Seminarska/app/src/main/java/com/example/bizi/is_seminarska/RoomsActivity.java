package com.example.bizi.is_seminarska;

import android.app.ActionBar;
import android.content.Intent;
import android.support.constraint.ConstraintLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TableLayout;
import android.widget.TableRow;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.HashMap;
import java.util.Map;

public class RoomsActivity extends AppCompatActivity {
    JSONArray rooms;
    TableLayout tableLayout;
    Map<Integer, String> buttonIDs;
    @Override
    public void onBackPressed() {
        super.onBackPressed();
        finish();
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_rooms);
        Intent intent = getIntent();
        buttonIDs = new HashMap<Integer, String>();
        tableLayout = (TableLayout)findViewById(R.id.roomTable);
        tableLayout.setLayoutParams(new ConstraintLayout.LayoutParams(
                ViewGroup.LayoutParams.MATCH_PARENT,
                ViewGroup.LayoutParams.MATCH_PARENT
        ));
        try {
            rooms = new JSONArray(intent.getStringExtra("roomJSON"));
            setRooms();
        }
        catch(JSONException e){
            Log.e("Volley", "Invalid JSONArray");

        }

    }

    private void setRooms(){
        JSONObject room;
        String imeSobe;
        TableRow tableRow;
        LinearLayout linearLayout;

        for(int i = 0; i < rooms.length(); i++){
            try {
                room = rooms.getJSONObject(i);
                imeSobe = room.getString("imeSobe");
                final Button button = new Button(this);
                button.setText(imeSobe);
                button.setId(imeSobe.hashCode());
                buttonIDs.put(imeSobe.hashCode(), imeSobe);
                button.setLayoutParams(new LinearLayout.LayoutParams(
                        ViewGroup.LayoutParams.MATCH_PARENT,
                        ActionBar.LayoutParams.WRAP_CONTENT
                ));
                button.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        checkRoom(button.getId());
                    }
                });
                tableRow = new TableRow(this);
                tableRow.setLayoutParams(new TableLayout.LayoutParams(
                        ViewGroup.LayoutParams.MATCH_PARENT,
                        ViewGroup.LayoutParams.WRAP_CONTENT
                ));
                linearLayout = new LinearLayout(this);
                linearLayout.setLayoutParams(new TableRow.LayoutParams(
                        ViewGroup.LayoutParams.MATCH_PARENT,
                        ViewGroup.LayoutParams.WRAP_CONTENT
                ));


                linearLayout.addView(button);
                tableRow.addView(linearLayout);
                tableLayout.addView(tableRow);
            }

            catch(JSONException e){
                Log.e("VolleyError", "JSONObject is invalid");
            }
        }
    }

    private void checkRoom(int bID){
        String imeSobe;
        JSONObject room;
        for(int i = 0; i < rooms.length(); i++){
            try {
                room = rooms.getJSONObject(i);
                imeSobe = room.getString("imeSobe");
                if(imeSobe.equals(buttonIDs.get(bID))){
                    Intent intent = new Intent(RoomsActivity.this, ValuesActivity.class);
                    intent.putExtra("senzorji", room.getJSONArray("senzorji").toString());
                    intent.putExtra("imeSobe", imeSobe);
                    startActivity(intent);
                }
            }
            catch(JSONException e){
                Log.e("Volley","Invalid JSONObject");
            }
        }
    }
}

