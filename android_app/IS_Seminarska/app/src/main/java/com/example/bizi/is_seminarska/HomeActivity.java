package com.example.bizi.is_seminarska;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.LinearLayout;
import android.widget.TextView;

public class HomeActivity extends AppCompatActivity {

    LinearLayout linearLayout;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);

        linearLayout = findViewById(R.id.linear_layout);

        for(int i = 0; i < 3; i++){
            TextView tv = new TextView(this);
            tv.setText("TEST" + String.valueOf(i));
            linearLayout.addView(tv);
        }
    }
}
