using UnityEngine;

namespace KartGame.KartSystems {

    public class KeyboardInput : BaseInput
    {
        public string TurnInputName = "Horizontal";
        public string AccelerateButtonName = "Accelerate";
        public string BrakeButtonName = "Brake";

        public float tolerance;

        public override InputData GenerateInput() {
            return new InputData
            {
                Accelerate = true,
                Brake = false,
                TurnInput = TurnDirection()
            };
        }

        private float TurnDirection()
        {
            var offset = new Vector2 (Screen.currentResolution.width, Screen.currentResolution.width) / 2;
            var pos = (Vector2)Input.mousePosition - offset;

            if (Mathf.Abs(pos.x) < tolerance) return 0;

            return Mathf.Sign(pos.x) / 2;
        }
    }
}
