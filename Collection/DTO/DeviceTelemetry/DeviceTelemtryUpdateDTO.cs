namespace Collection.DTO.DeviceTelemetry
{
    public class DeviceTelemtryUpdateDTO
    {
        public float Temp { get; set; }
        public float Press { get; set; }

        public int BattLevel { get; set; }
        public string Status { get; set; } = null!;

    }
}
