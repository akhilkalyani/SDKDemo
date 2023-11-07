using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GF;
using DG.Tweening;
using System;

namespace TPSDK
{
    public class LoadingUI : DefaultLoadingUI
    {
        public override void Load(Action complete)
        {
            loadRoutine = StartCoroutine(ShowLoadingScreenCoroutine(complete));
        }

        public override void Unload(Action complete)
        {
            unloadRoutine = StartCoroutine(CloseLoadingScreenCoroutine(complete));
        }

        private  IEnumerator ShowLoadingScreenCoroutine(Action complete)
        {
            safeArea.GetComponent<CanvasGroup>().alpha = 1f;
            yield return new WaitUntil(() => loadRoutine == null && unloadRoutine==null);
            safeArea.SetActive(true);
            _loadState.gameObject.SetActive(true);
            yield return new WaitForSeconds(_loadState.GetCurrentAnimatorStateInfo(0).length);
            _idleState.SetActive(true);
            _loadState.gameObject.SetActive(false);
            loadRoutine = null;
            complete?.Invoke();
        }
        
        
        private  IEnumerator CloseLoadingScreenCoroutine(Action complete)
        {
            yield return new WaitUntil(()=>unloadRoutine==null && loadRoutine==null);
            yield return new WaitForSeconds(_minimumWaitDuration);
            UpdateProgress(1f);
            yield return new WaitForSeconds(0.2f);
            _idleState.SetActive(false) ;
            _unloadState.gameObject.SetActive(true) ;
            yield return new WaitForSeconds(_unloadState.GetCurrentAnimatorStateInfo(0).length);
            _unloadState.gameObject.SetActive(false);
            yield return Lerp(safeArea.GetComponent<CanvasGroup>(),0.3f);
            safeArea.SetActive(false);
            unloadRoutine = null;
            complete?.Invoke();
        }
        private IEnumerator Lerp(CanvasGroup grp,float delay)
        {
            float t = 0;
            while(t<=1)
            {
                t+= (1/delay)*Time.deltaTime;
                grp.alpha = Mathf.Lerp(1, 0, t);
                yield return null;
            }
        }
    }
}
