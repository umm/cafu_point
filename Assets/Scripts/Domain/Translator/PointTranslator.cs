using CAFU.Core.Domain.Translator;
using CAFU.Point.Data.Entity;
using CAFU.Point.Domain.Model;

namespace CAFU.Point.Domain.Translator
{
    public class PointModelTranslator : IModelTranslator<PointEntity, PointModel>
    {
        public PointModel Translate(PointEntity entity)
        {
            return new PointModel(entity?.Point ?? 0);
        }
    }

    public class PointEntityTranslator : IEntityTranslator<PointModel, PointEntity>
    {
        public PointEntity Translate(PointModel model)
        {
            return new PointEntity
            {
                Point = model?.Point?.Value ?? 0
            };
        }
    }
}