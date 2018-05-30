using CAFU.Core.Domain.Model;
using UniRx;

namespace CAFU.Point.Domain.Model
{
    public class PointModel : IModel
    {
        public ReactiveProperty<int> Point { get; set; }

        public PointModel(int point)
        {
            this.Point = new ReactiveProperty<int>(point);
        }
    }
}