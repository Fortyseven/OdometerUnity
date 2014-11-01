using UnityEngine;
using System.Collections;

public class OdometerController : MonoBehaviour
{
    public int MAX_DIGITS = 7;

    public OdometerDigitSpinner[]   Spinners;
    public float                    SpinnerSpeed = 1.0f;
    public int                      InitialValue = 0;

    private int _value = 0;

#region Properties
    public int MaxValue { get { return Mathf.RoundToInt( Mathf.Pow( 10, MAX_DIGITS ) )-1; } }
    public int Value { get { return _value; } }
#endregion

    // Use this for initialization
    void Start()
    {
        Debug.Log(MaxValue);
        SetValue( InitialValue );
    }

    public void Reset()
    {
        SetValue( InitialValue );
    }

    //      public void SetValueBy ()
    //      {
    //              _value++;
    //              SetValue (_value);  
    //      }

    /// <summary>
    /// Increments the current value by an amount (plus or minus).
    /// </summary>
    /// <param name="increment_by">Value to change by.</param>
    public void SetValueBy( int increment_by )
    {
        _value += increment_by;
        SetValue( _value );
    }


    /// <summary>
    /// Sets the current value of the
    /// </summary>
    /// <param name="value">Value.</param>
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