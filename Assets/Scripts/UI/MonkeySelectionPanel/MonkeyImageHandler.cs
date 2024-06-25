using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ServiceLocator.UI
{
    public class MonkeyImageHandler : MonoBehaviour, IDragHandler, IDropHandler
    {
        private Image monkeyImage;
        private MonkeyCellController owner;
        private Sprite spriteToSet;
        private RectTransform rectTransform;
        private RectTransform originalPosition;
        private Vector3 originalAnchoredPos;
        private void ResetMonkey()
        {
            rectTransform = originalPosition;
            GetComponent<LayoutElement>().enabled = false;
            GetComponent<LayoutElement>().enabled = true;
        }

        public void ConfigureImageHandler(Sprite spriteToSet, MonkeyCellController owner)
        {
            this.spriteToSet = spriteToSet;
            this.owner = owner;
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta;
            owner.MonkeyDraggedAt(rectTransform.position);
        }

        public void OnDrop(PointerEventData eventData)
        {
            owner.MonkeyDroppedAt(eventData.position);
            ResetMonkey();
        }

        private void Awake()
        {
            monkeyImage = GetComponent<Image>();
            monkeyImage.sprite = spriteToSet;
            rectTransform = GetComponent<RectTransform>();
            originalPosition = rectTransform;
            originalAnchoredPos=rectTransform.anchoredPosition;
        }



    }
}