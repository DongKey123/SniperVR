using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct InteractiveModelData
{
    public enum InteractiveObjectType : int
    {
        NONE,
        MACHINE_PORTERFILTER,
        GRINDER_DOSINGLEVER,
		GRINDER_PORTERFILTERHOLDER,
        GRINDER_SWITCH,
		TAMPER,
		TAMPER_HOLDER,
		ESPRESSO_BUTTON,
		COFFEE_GRASS,
		DISH,
        MILKPACK,
        MILKPITCHER,
		STEAM_LEVER
    }

    public InteractiveObjectType m_modelType;
    public Vector3 m_modelRotate;
    public Vector3 m_modelAnchorPosition;

	public Vector3 m_modelRightRotate;
	public Vector3 m_modelRightAnchorPosition;
}