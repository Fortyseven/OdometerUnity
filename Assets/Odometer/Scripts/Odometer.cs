using UnityEngine;
using System.Collections;

public class Odometer : MonoBehaviour
{
    public OdometerDigitSpinner[] Spinners;
    public float SpinnerSpeed = 1.0f;
	int _value = 0;

    // Use this for initialization
    void Start()
    {
        SetValue( _value );
    }

    public void IncrementDigit()
    {
        _value++;
        SetValue( _value );  
    }
    
    public void SetValue( int value )
    {
        Spinners[ 0 ].SetValue( value % 10 );
        Spinners[ 1 ].SetValue( Mathf.Abs( ( value % 100 ) / 10 ) );
        Spinners[ 2 ].SetValue( Mathf.Abs( ( value % 1000 ) / 100 ) );
        Spinners[ 3 ].SetValue( Mathf.Abs( ( value % 10000 ) / 1000 ) );
        Spinners[ 4 ].SetValue( Mathf.Abs( ( value % 100000 ) / 10000 ) );
        Spinners[ 5 ].SetValue( Mathf.Abs( ( value % 1000000 ) / 100000 ) );
        Spinners[ 6 ].SetValue( Mathf.Abs( ( value % 10000000 ) / 1000000 ) );
                
        _value = value;
    }
}
