//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google LLC">
// Copyright 2020 Google LLC
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
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;

/// <summary>
/// Controls target objects behaviour.
/// </summary>
public class AnimalController : MonoBehaviour
{
    public delegate void whack();
    public event whack OnWhack;

    public GameObject hammer;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        // _startingPosition = transform.parent.localPosition;
        // _myRenderer = GetComponent<Renderer>();
        // SetMaterial(false);
    }

    public void OnPointerClick()
    {
        GameObject hammer_copy = Instantiate(hammer);
        AngleHammerAnimation hammer_script = hammer_copy.AddComponent<AngleHammerAnimation>();
        hammer_script.animal = this;
        hammer_script.OnCopyCreated();
        OnWhack();
    }
}
