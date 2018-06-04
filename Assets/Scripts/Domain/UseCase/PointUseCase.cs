using System;
using CAFU.Core.Domain.UseCase;
using CAFU.KeyValueStore.Domain.Repository;
using CAFU.Point.Data.Entity;
using CAFU.Point.Domain.Model;
using CAFU.Point.Domain.Translator;

namespace CAFU.Point.Domain.UseCase
{
    public interface IPointUseCase : IUseCase
    {
        /// <summary>
        /// Save results into keyvalue file.
        /// </summary>
        void Save();

        /// <summary>
        /// Load results into keyvalue file.
        /// </summary>
        void Load();

        /// <summary>
        /// Reset result point.
        /// </summary>
        void Reset();

        /// <summary>
        /// The value of point
        /// </summary>
        int Point { get; set; }

        /// <summary>
        /// Stream for points
        /// </summary>
        IObservable<int> PointAsObservable { get; }
    }

    public class PointUseCase : IPointUseCase
    {
        public class Factory : DefaultUseCaseFactory<PointUseCase>
        {
            private string Key = null;

            private string SavePath = null;

            protected override void Initialize(PointUseCase instance)
            {
                base.Initialize(instance);

                instance.Initialize(this.SavePath, this.Key);
            }

            /// <summary>
            /// Please use Create(savePath, key)
            /// </summary>
            /// <returns></returns>
            /// <exception cref="System.NotImplementedException"></exception>
            public override PointUseCase Create()
            {
                throw new NotImplementedException("Please use `Create(key)` method");
            }

            /// <summary>
            /// Create PointUseCase instance.
            /// </summary>
            /// <param name="savePath">It's location to save keyvalue. e.g. `UnityEngine.Application.persistentDataPath + "/default.kv"`</param>
            /// <param name="key">It's key to get/set entity</param>
            /// <returns></returns>
            public PointUseCase Create(string savePath, string key)
            {
                this.SavePath = savePath;
                this.Key = key;
                return base.Create();
            }
        }

        private IKeyValueRepository Repository { get; set; }

        private PointModelTranslator ModelTranslator { get; set; }

        private PointEntityTranslator EntityTranslator { get; set; }

        private string Key { get; set; }

        public int Point
        {
            get { return this.Model.Point.Value; }
            set { this.Model.Point.Value = value; }
        }

        public IObservable<int> PointAsObservable
        {
            get { return this.Model.Point; }
        }

        private PointModel Model { get; set; }

        protected void Initialize(string savePath, string key)
        {
            this.Repository = new DefaultKeyValueRepository.Factory().Create(savePath);
            this.ModelTranslator = new PointModelTranslator();
            this.EntityTranslator = new PointEntityTranslator();
            this.Key = key;
            this.Model = new PointModel(0);
        }

        public void Save()
        {
            var entity = this.EntityTranslator.Translate(this.Model);
            this.Repository.SetEntity(this.Key, entity);
            this.Repository.Save();
        }

        public void Load()
        {
            this.Repository.Load();

            var entity = this.Repository.GetEntity<PointEntity>(this.Key);
            this.Model = this.ModelTranslator.Translate(entity);
        }

        public void Reset()
        {
            this.Model.Point.Value = 0;
        }
    }
}