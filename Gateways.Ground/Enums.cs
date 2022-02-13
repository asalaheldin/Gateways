using System;

namespace Gateways.Ground
{
    public enum ValidationStatus
    {
        BadRequest = 400,
        NotFound = 404,
        Unauthorized = 401,
        Accepted = 202
    }

    public enum PeripheralStatus
    {
        Offline = 0,
        Online = 1
    }
}
