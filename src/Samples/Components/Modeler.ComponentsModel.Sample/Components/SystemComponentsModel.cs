﻿namespace Modeler.ComponentsModel.Sample.Components;

public class SystemComponentsModel : Model
{
    private static SystemComponentsModel? _instance;

    public static SystemComponentsModel GetInstance()
    {
        if (_instance == null)
        {
            _instance = new SystemComponentsModel();
        }

        return _instance;
    }
}