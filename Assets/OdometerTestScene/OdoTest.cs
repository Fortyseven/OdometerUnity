using UnityEngine;
using System.Collections;

public class OdoTest : MonoBehaviour
{
    public GameObject LargeOdo, SmallOdo;
    OdometerController _olarge, _osmall;

    void Start()
    {
        _olarge = LargeOdo.GetComponent<OdometerController>();
        _osmall = SmallOdo.GetComponent<OdometerController>();
    }

    void OnGUI()
    {
        if ( GUI.Button( new Rect( 20, 60, 100, 40 ), "+ Large Odo" ) ) {
            _olarge.SetValueBy( 1 );
        }
        if ( GUI.Button( new Rect( 125, 60, 100, 40 ), "- Large Odo" ) ) {
            _olarge.SetValueBy( -1 );
        }
        if ( GUI.Button( new Rect( 230, 60, 160, 40 ), "Set Large Odo Random" ) ) {
            _olarge.SetValue( Random.Range( 0, _olarge.MaxValue ) );
        }
        if ( GUI.Button( new Rect( 395, 60, 80, 40 ), "RESET LG" ) ) {
            _olarge.Reset();
        }

        if ( GUI.Button( new Rect( 20, 100, 100, 40 ), "+ Small Odo" ) ) {
            _osmall.SetValueBy( 1 );
        }
        if ( GUI.Button( new Rect( 125, 100, 100, 40 ), "- Small Odo" ) ) {
            _osmall.SetValueBy( -1 );
        }
        if ( GUI.Button( new Rect( 230, 100, 160, 40 ), "Set Small Odo Random" ) ) {
            _osmall.SetValue( Random.Range( 0, _olarge.MaxValue ) );
        }
        if ( GUI.Button( new Rect( 395, 100, 80, 40 ), "RESET SM" ) ) {
            _osmall.Reset();
        }
    }
}
