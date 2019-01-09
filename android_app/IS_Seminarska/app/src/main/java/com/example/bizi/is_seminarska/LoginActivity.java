package com.example.bizi.is_seminarska;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.android.volley.RequestQueue;
import com.android.volley.VolleyError;
import com.android.volley.Response;
import com.android.volley.Request;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;

public class LoginActivity extends AppCompatActivity {
    private Button b;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_login);
        b = (Button)findViewById(R.id.button);

    }

    public void onClick(View v){
        EditText in = (EditText)findViewById(R.id.user);
        final String user = in.getText().toString();
        in = (EditText)findViewById(R.id.pass);
        final String pass = in.getText().toString();
        RequestQueue queue = Volley.newRequestQueue(this);  // this = context
        String url = String.format("https://houcellbase.ddns.net:44305/api/login?userName=%s&pass=%s", user, pass);
        Trust.trustEveryone();

// prepare the Request

        JsonArrayRequest arrReq = new JsonArrayRequest(Request.Method.GET, url,
                new Response.Listener<JSONArray>() {
                    @Override
                    public void onResponse(JSONArray response) {
                        // Check the length of our response (to see if the user has any repos)
                        if (response.length() > 0) {
                            // The user does have repos, so let's loop through them all.
                            for (int i = 0; i < response.length(); i++) {
                                try {
                                    // For each repo, add a new line to our repo list.
                                    Integer jsonObj = response.getInt(i);
                                    if(jsonObj != -1){
                                        Intent intent = new Intent(LoginActivity.this, HomeActivity.class);
                                        intent.putExtra("logID", jsonObj);
                                        startActivity(intent);

                                    }
                                    setB(true);


                                } catch (JSONException e) {
                                    // If there is an error then output this to the logs.
                                    Log.e("Volley", "Invalid JSON Object.");
                                    setContentView(R.layout.activity_login);

                                }

                            }
                        } else {
                            // The user didn't have any repos.
                        }

                    }
                },

                new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        // If there a HTTP error then add a note to our repo list.

                        Log.e("Volley", error.toString());
                        setB(true);
                    }
                }
        );
        // Add the request we just defined to our request queue.
        // The request queue will automatically handle the request as soon as it can.
        queue.add(arrReq);
        queue.start();
       setB(false);
    }



    private void setB(boolean state){
        b.setEnabled(state);
    }
}
