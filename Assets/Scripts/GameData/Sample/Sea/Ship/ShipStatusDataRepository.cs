namespace OskaKim.GameData.Sample.Sea.Ship
{
    public class ShipStatusDataRepository
    {
        // 현재 스피드. 후진시엔 마이너스 수치
        public float CurrentlySpeed { get; set; } = 0;

        // 엔진파워. 전후방 조작시 스피드에 가산하는 방식
        public float ForwardEnginePower { get; set; } = 0.005f;
        public float BackEnginePower { get; set; } = 0.003f;

        // 저항치. 엔진파워가 가해지지 않을때 이 값만큼 스피드가 0에 가까워짐
        public float Resistance { get; set; } = 0.005f;

        // 최대 스피드.
        public float MaxSpeed { get; set; } = 2f;

        // 현재의 회전 스피드.
        public float CurrentlyRotateSpeed { get; set; } = 0;

        // 회전 엔진 파워.
        public float RotateEnginePower { get; set; } = 0.2f;

        // 회전 최대 스피드
        public float MaxRotateSpeed { get; set; } = 5f;
    }
}
