using CosmicCuration.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXPool : GenericObjectPool<VFXController>
    {
        private VFXData vfxData;

        public VFXController GetVFX(VFXData vfxData)
        {
            this.vfxData = vfxData;
            return GetItem<VFXController>();
        }


        protected override VFXController CreateItem<T>()
        {
            if (vfxData.type == VFXType.PlayerExplosion)
            {
                
            }
        }
    }
}
