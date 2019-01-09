package com.example.bizi.is_seminarska;

import android.app.ActionBar;
import android.content.Context;
import android.content.Intent;
import android.support.constraint.ConstraintLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.AttributeSet;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.view.ViewManager;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.RelativeLayout;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.HashMap;
import java.util.Map;

public class HomeActivity extends AppCompatActivity {

    TableLayout tableLayout;
    JSONArray houses;
    Map<Integer, String> buttonIDs;
    int logID;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);
        buttonIDs = new HashMap<Integer, String>();
        tableLayout = (TableLayout)findViewById(R.id.tableLayout);
        tableLayout.setLayoutParams(new ConstraintLayout.LayoutParams(
                ViewGroup.LayoutParams.MATCH_PARENT,
                ViewGroup.LayoutParams.MATCH_PARENT
        ));
        logID = getIntent().getIntExtra("logID", -1);
        requestData();
    }

    @Override
    protected void onStart() {
        super.onStart();



    }


    private void setHouses(JSONArray res){
        this.houses = res;
        JSONObject house;
        String naslov;
        TableRow tableRow;
        LinearLayout linearLayout;

        for(int i = 0; i < houses.length(); i++){
            try {
                house = houses.getJSONObject(i);
                naslov = house.getString("naslov");
                final Button button = new Button(this);
                button.setText(naslov);
                button.setId(naslov.hashCode());
                buttonIDs.put(naslov.hashCode(), naslov);
                button.setLayoutParams(new LinearLayout.LayoutParams(
                        ViewGroup.LayoutParams.MATCH_PARENT,
                        ActionBar.LayoutParams.WRAP_CONTENT
                        ));
                button.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        checkHouse(button.getId());
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

    private void checkHouse(int bID){
        String naslov;
        JSONObject house;
        for(int i = 0; i < houses.length(); i++){
            try {
                house = houses.getJSONObject(i);
                naslov = house.getString("naslov");
                if(naslov.equals(buttonIDs.get(bID))){
                    Intent intent = new Intent(HomeActivity.this, RoomsActivity.class);
                    intent.putExtra("roomJSON", house.getJSONArray("soba").toString());
                    startActivity(intent);
                }
            }
            catch(JSONException e){
                Log.e("Volley","Invalid JSONObject");
            }
        }
    }

    private void requestData(){
        String url = String.format("https://houcellbase.ddns.net:44305/api/uporabnik/%d", logID);
        RequestQueue queue = Volley.newRequestQueue(this);  // this = context
        Trust.trustEveryone();
        JsonArrayRequest arrReq = new JsonArrayRequest(Request.Method.GET, url,
                new Response.Listener<JSONArray>() {
                    @Override
                    public void onResponse(JSONArray response) {
                        // Check the length of our response (to see if the user has any repos)
                        setHouses(response);

                    }
                },

                new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        // If there a HTTP error then add a note to our repo list.

                        Log.e("Volley", error.toString());
                    }
                }
        );
        // Add the request we just defined to our request queue.
        // The request queue will automatically handle the request as soon as it can.
        queue.add(arrReq);
        queue.start();
    }

    public void refresh(View v){
        for(int i = 0; i < tableLayout.getChildCount(); i++){
            ((ViewManager)tableLayout).removeView(tableLayout.getChildAt(i));
        }
        requestData();

    }
}
/*tableLayout = (TableLayout)findViewById(R.id.tableLayout);
        String a;
        TableRow tr;
        LinearLayout ll;
        Button tv;
        for(int i = 0; i < 3; i++){
            tr = new TableRow(this);
            ll = new LinearLayout(this);
            for(int j = 0; j < 3; j++) {


                tv = new Button(this);
                a = "TEST" + String.valueOf(i) + String.valueOf(j);
                tv.setText(a);
                ll.addView(tv);
            }
            tr.addView(ll);

            tableLayout.addView(tr);
        }*/