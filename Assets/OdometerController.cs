using UnityEngine;
using System.Collections;

public class OdometerController : MonoBehaviour
{
    public int InitialValue = 0;

    Odometer _odo;

    void Start()
    {
        _odo = GetComponentInChildren<Odometer>();      
        if ( _odo == null ) {
            throw new UnityException( "Could not find child Odometer component" );
        }

        _odo.SetValue(InitialValue);
    }

    void SetValue(int value)
    {
        _odo.SetValue(value);
    }
}
