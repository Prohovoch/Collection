namespace Collection.DTO.RobotTelemetry
{
    public class RobotTelemetryUpdateDTO
    {
        public string RobotType { get; set; } = null!;

        public string Status { get; set; } = null!;
        public int PosX { get; set; }
        public int PosY { get; set; }

        public int Battery { get; set; }

        public float Speed { get; set; }

    }
}
