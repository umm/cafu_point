using CAFU.Core.Presentation.View;
using CAFU.Point.Example.Presentation.Presenter;

namespace CAFU.Point.Example.Presentation.View
{
    public class Controller : Controller<Controller, PointExamplePresenter,PointExamplePresenter.Factory>
    {
        protected override void OnStart()
        {
            base.OnStart();
            
            this.GetPresenter<PointExamplePresenter>().Load();
        }
    }
}