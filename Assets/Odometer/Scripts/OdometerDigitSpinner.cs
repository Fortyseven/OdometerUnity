using UnityEngine;
using System.Collections;

public class OdometerDigitSpinner : MonoBehaviour
{
    const float NUMERIC_OFFSET_MULTIPLIER = 36.5f;
    const float TURN_SPEED = 0.5f;

    public GameObject ChildSpinner = null;

    private int _my_value = 0;
	    
    public void SetValue( int new_value )
    {
        float from, to;

        from = NUMERIC_OFFSET_MULTIPLIER * ( _my_value % 10 );

        if ( new_value < _my_value ) {
            to = NUMERIC_OFFSET_MULTIPLIER * ( ( new_value % 10 ) + 10 );
        } else { 
            to = NUMERIC_OFFSET_MULTIPLIER * ( ( new_value % 10 ) );
        }

        StartCoroutine("TweenUpdate", new float[2]{from,to});

                
        _my_value = new_value;
    }
        
    public void assface( float val )
    {

    }


    IEnumerator TweenUpdate(float[] param)
    {
        float from = param[0];
		float to = param[1] - from;
		float end_time = Time.time + TURN_SPEED;

		while(Time.time <= end_time) {
			float val = getTweenValue(Time.time, from, to, end_time);
			transform.rotation = Quaternion.AngleAxis( val, transform.right );
			yield return null;
		}
//		Debug.Log(mCurrentValue + " Done: " + val + " FROM: " + from + " TO: " + to);
    }

    float getTweenValue(float t_curtime, float b_startval, float c_amounttotal, float d_totaltime)
    {
        return c_amounttotal * t_curtime / d_totaltime + b_startval;
    }

}
