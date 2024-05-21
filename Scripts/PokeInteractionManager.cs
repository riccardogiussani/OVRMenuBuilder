/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Oculus.Interaction;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PokeInteractionManager : MonoBehaviour
{
    public UnityEvent onPoke;

    private IInteractableView InteractableView { get; set; }


    protected virtual void Awake()
    {
        InteractableView = GetComponentInChildren<IInteractableView>();
    }

    protected virtual void OnEnable()
    {
        InteractableView.WhenStateChanged += OnPoke;
    }

    protected virtual void OnDisable()
    {
        InteractableView.WhenStateChanged -= OnPoke;
    }

    private void OnPoke(InteractableStateChangeArgs args)
    {
        OnPoke();
    }

    protected virtual void OnPoke()
    {
        if(InteractableView.State == InteractableState.Select)
        {
            onPoke.Invoke();
        }
    }

    public void ToggleCanvas(GameObject go)
    {
        go.SetActive(!go.activeSelf);
    }

    public void DebugButton()
    {
        if (onPoke != null)
        {
            onPoke.Invoke();
        }
    }
}