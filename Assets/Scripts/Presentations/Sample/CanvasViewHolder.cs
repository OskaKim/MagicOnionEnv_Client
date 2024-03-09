using UnityEngine;

namespace OskaKim.Presentations
{
    public class CanvasViewHolder
    {
        // TODO : canvas를 view로써 정의해서 사용하기
        public Canvas MainCanvas { get; private set; }
        public RectTransform MainCanvasRectTransform { get; private set; }

        public void SetMainCanvas(Canvas canvas)
        {
            MainCanvas = canvas;
            MainCanvasRectTransform = canvas.GetComponent<RectTransform>();
        }
    }
}
