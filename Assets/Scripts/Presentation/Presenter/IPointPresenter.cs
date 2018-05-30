using CAFU.Core.Presentation.Presenter;
using CAFU.Point.Domain.UseCase;

namespace CAFU.Point.Presentation.Presenter
{
    public interface IPointPresenter : IPresenter
    {
        IPointUseCase PointUseCase { get; }
    }

    public static class IPointPresenterExtension
    {
        public static void LoadPoint(this IPointPresenter presenter)
        {
            presenter.PointUseCase.Load();
        }

        public static void SavePoint(this IPointPresenter presenter)
        {
            presenter.PointUseCase.Save();
        }

        public static void ResetPoint(this IPointPresenter presenter)
        {
            presenter.PointUseCase.Reset();
        }

        public static void SetPoint(this IPointPresenter presenter, int point)
        {
            presenter.PointUseCase.Point = point;
        }

        public static void AddPoint(this IPointPresenter presenter, int additionalPoint)
        {
            presenter.PointUseCase.Point += additionalPoint;
        }

        public static int GetPoint(this IPointPresenter presenter)
        {
            return presenter.PointUseCase.Point;
        }

        public static UniRx.IObservable<int> GetPointAsObservable(this IPointPresenter presenter)
        {
            return presenter.PointUseCase.PointAsObservable;
        }
    }
}