# cafu_point

## What

* Storing game point into key value files.

## Requirement

* cafu_core
* cafu_kvs

## Install

```shell
yarn add "umm/cafu_point#^1.0.0"
```

## Usage

```csharp
public class MyPresenter : IPointPresenter
{
    public IPointUseCase PointUseCase { get; private set; } 
}
```

Now you can call point methods from presenter.

```csharp
presenter.LoadPoint();
presenter.SavePoint();
presenter.ResetPoint();
presenter.SetPoint(10);
presenter.AddPoint(1);
presenter.GetPoint();
presenter.GetPointAsObservable();
```

or refer usecase on your presenter.

```csharp
usecase.Load();
usecase.Save();
usecase.Reset();
usecase.Point = 10;
usecase.Point += 10;
usecase.PointAsObservable();
```

## License

Copyright (c) 2018 Takuma Maruyama

Released under the MIT license, see [LICENSE.txt](LICENSE.txt)

