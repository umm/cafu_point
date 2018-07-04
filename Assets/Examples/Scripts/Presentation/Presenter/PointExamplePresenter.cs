using CAFU.Core.Presentation.Presenter;
using CAFU.Point.Domain.UseCase;
using CAFU.Point.Presentation.Presenter;

namespace CAFU.Point.Example.Presentation.Presenter
{
    public class PointExamplePresenter :
        IPointPresenter
    {
        public class Factory : DefaultPresenterFactory<PointExamplePresenter>
        {
            protected override void Initialize(PointExamplePresenter instance)
            {
                base.Initialize(instance);
                instance.PointUseCase = new PointUseCase.Factory().Create(UnityEngine.Application.persistentDataPath + "/sample.kv", "key");
            }
        }

        public IPointUseCase PointUseCase { get; private set; }

        public void Load()
        {
            this.PointUseCase.Load();
        }
    }
}