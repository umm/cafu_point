using CAFU.Core.Presentation.View;
using CAFU.Point.Presentation.Presenter;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace CAFU.Point.Example.Presentation.View
{
    [RequireComponent(typeof(Button))]
    public class ButtonGet : MonoBehaviour, IView
    {
        void Start()
        {
            this.GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ => Debug.Log(this.GetPresenter<IPointPresenter>().GetPoint()))
                .AddTo(this);
        }
    }
}