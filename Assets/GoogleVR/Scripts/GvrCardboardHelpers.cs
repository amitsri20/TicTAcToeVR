// Copyright 2017 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using UnityEngine.VR;

using System;
using System.Runtime.InteropServices;

// General GVR helpers.
public class GvrCardboardHelpers {
  /// Manual recenter for Cardboard.
  /// Do not use for controller-based Daydream recenter - Google VR Services will take care
  /// of that, no C# implementation behaviour is needed.
  /// Apply the recenteringOffset to the Camera or its parent at runtime.
  public static void Recenter() {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
    gvr_reset_tracking(UnityEngine.XR.XRDevice.GetNativePtr());
#endif  // (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
    Debug.Log("Use GvrEditorEmulator for in-editor recentering");
  }

  /// Set the Cardboard viewer params.
  /// Example URI for 2015 Cardboard Viewer V2:
  /// http://google.com/cardboard/cfg?p=CgZHb29nbGUSEkNhcmRib2FyZCBJL08gMjAxNR0rGBU9JQHegj0qEAAASEIAAEhCAABIQgAASEJYADUpXA89OggeZnc-Ej6aPlAAYAM
  public static void SetViewerProfile(String viewerProfileUri) {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
    gvr_set_default_viewer_profile(UnityEngine.XR.XRDevice.GetNativePtr(), viewerProfileUri);
#endif  // (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
    Debug.Log("Unavailable for non-Android and non-iOS builds");
  }

#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
  [DllImport(GvrActivityHelper.GVR_DLL_NAME)]
  private static extern void gvr_reset_tracking(IntPtr gvr_context);

  [DllImport(GvrActivityHelper.GVR_DLL_NAME)]
  private static extern void gvr_set_default_viewer_profile(IntPtr gvr_context,
      [MarshalAs(UnmanagedType.LPStr)] string viewer_profile_uri);
#endif  // (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

}
