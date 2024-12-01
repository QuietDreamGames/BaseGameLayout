#if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (https://www.swig.org).
// Version 4.2.1
//
// Do not make changes to this file unless you know what you are doing - modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class AkGeometryInstanceParams : global::System.IDisposable {
  private global::System.IntPtr swigCPtr;
  protected bool swigCMemOwn;

  internal AkGeometryInstanceParams(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  internal static global::System.IntPtr getCPtr(AkGeometryInstanceParams obj) {
    return (obj == null) ? global::System.IntPtr.Zero : obj.swigCPtr;
  }

  internal virtual void setCPtr(global::System.IntPtr cPtr) {
    Dispose();
    swigCPtr = cPtr;
  }

  ~AkGeometryInstanceParams() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkUnitySoundEnginePINVOKE.CSharp_delete_AkGeometryInstanceParams(swigCPtr);
        }
        swigCPtr = global::System.IntPtr.Zero;
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public AkGeometryInstanceParams() : this(AkUnitySoundEnginePINVOKE.CSharp_new_AkGeometryInstanceParams(), true) {
  }

  public AkWorldTransform PositionAndOrientation { set { AkUnitySoundEnginePINVOKE.CSharp_AkGeometryInstanceParams_PositionAndOrientation_set(swigCPtr, AkWorldTransform.getCPtr(value)); } 
    get {
      global::System.IntPtr cPtr = AkUnitySoundEnginePINVOKE.CSharp_AkGeometryInstanceParams_PositionAndOrientation_get(swigCPtr);
      AkWorldTransform ret = (cPtr == global::System.IntPtr.Zero) ? null : new AkWorldTransform(cPtr, false);
      return ret;
    } 
  }

  public UnityEngine.Vector3 Scale { set { AkUnitySoundEnginePINVOKE.CSharp_AkGeometryInstanceParams_Scale_set(swigCPtr, value); }  get { return AkUnitySoundEnginePINVOKE.CSharp_AkGeometryInstanceParams_Scale_get(swigCPtr); } 
  }

  public bool UseForReflectionAndDiffraction { set { AkUnitySoundEnginePINVOKE.CSharp_AkGeometryInstanceParams_UseForReflectionAndDiffraction_set(swigCPtr, value); }  get { return AkUnitySoundEnginePINVOKE.CSharp_AkGeometryInstanceParams_UseForReflectionAndDiffraction_get(swigCPtr); } 
  }

  public bool BypassPortalSubtraction { set { AkUnitySoundEnginePINVOKE.CSharp_AkGeometryInstanceParams_BypassPortalSubtraction_set(swigCPtr, value); }  get { return AkUnitySoundEnginePINVOKE.CSharp_AkGeometryInstanceParams_BypassPortalSubtraction_get(swigCPtr); } 
  }

  public bool IsSolid { set { AkUnitySoundEnginePINVOKE.CSharp_AkGeometryInstanceParams_IsSolid_set(swigCPtr, value); }  get { return AkUnitySoundEnginePINVOKE.CSharp_AkGeometryInstanceParams_IsSolid_get(swigCPtr); } 
  }

}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.