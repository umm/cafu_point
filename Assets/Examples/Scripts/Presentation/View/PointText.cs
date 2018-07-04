using CAFU.Core.Presentation.View;
using CAFU.Point.Presentation.Presenter;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace CAFU.Point.Example.Presentation.View
{
    [RequireComponent(typeof(Text))]
    public class PointText : MonoBehaviour, IView
    {
        public string Format = "{0}";

        void Start()
        {
            this.GetPresenter<IPointPresenter>().GetPointAsObservable()
                .Subscribe(this.Render)
                .AddTo(this);
        }

        void Render(int point)
        {
            this.GetComponent<Text>().text = string.Format(this.Format, point);
        }
    }
}