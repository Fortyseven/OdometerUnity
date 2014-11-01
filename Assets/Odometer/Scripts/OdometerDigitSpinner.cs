using UnityEngine;
using System.Collections;

public class OdometerDigitSpinner : MonoBehaviour
{
    const float         NUMERIC_OFFSET_MULTIPLIER = 36.0f;
    const float         TURN_SPEED                = 0.25f;
    public GameObject   ChildSpinner              = null;
    private int         _my_value                 = 0;

    /// <summary>
    /// Changes the value displayed on the wheel.
    /// </summary>
    /// <param name="new_value">New_value.</param>
    public void SetValue( int new_value )
    {
        float from, to;

        int a = ( _my_value + new_value ) % 10;
        int b = ( _my_value - new_value ) % 10;
        Debug.Log( "Going from " + _my_value + " to " + new_value + " A = " + a + " B = " + b );

        //        if ((_my_value + new_value) >= 10)

        from = NUMERIC_OFFSET_MULTIPLIER * ( _my_value % 10 );
        to = NUMERIC_OFFSET_MULTIPLIER * ( new_value % 10 );

        if ( from != 0 || to != 0 ) {
            Debug.Log( from + " [" + _my_value + "] > " + to + " [" + new_value + "]" );
        }

        StartCoroutine( "TweenUpdate", new float[] { from, to } );

        _my_value = new_value;
    }

    /*************************************************************************/
    IEnumerator TweenUpdate( float[] param )
    {
        float from = param[ 0 ];
        float to;
        to = param[ 1 ] - param[ 0 ];
        //        if ( param[ 0 ] < param[ 1 ] ) {
        //            to = param[ 1 ] - param[ 0 ];
        //        } 
        //        else {
        //            to = param[ 0 ] - param[ 1 ];
        //        }

        float start_time = Time.time;
        float end_time = TURN_SPEED;
        float val = 0;
        bool dbug = false;

        if ( from != 0 || to != 0 ) {
            dbug = true;
        }
        if ( dbug ) {
            //Debug.Log( "from: " + from + " amount " + to + " [0] = " + param[ 0 ] + " [1] = " + param[ 1 ] );
        }

        while ( Time.time - start_time <= end_time ) {
            float t = Time.time;
            val = getTweenValue( Time.time - start_time, from, to, end_time );
            transform.rotation = Quaternion.AngleAxis( val, transform.right );
            yield return null;
        }
        //transform.rotation = Quaternion.AngleAxis(NUMERIC_OFFSET_MULTIPLIER * (_my_value % 10), transform.right);
    }

    /*************************************************************************/
    float getTweenValue( float t_curtime, float b_startval, float c_amounttotal, float d_totaltime )
    {
        return ( c_amounttotal * ( t_curtime / d_totaltime ) ) + b_startval;
    }
}
