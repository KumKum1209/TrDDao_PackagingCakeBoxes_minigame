using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Cake : Characters
{
    
  
    public void OnMouseDown()
    {

        objectStartPosition = transform.position;

    }

    public void OnMouseUp()
    {
        isDragging = false;
        
        Vector2 mouseEndPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

        Vector2 moveDirection = (mouseEndPosition - objectStartPosition).normalized;
        Direction dir = DetermineDirection(moveDirection);
        Moving(dir);
        GameController.instance.box.GetComponent<Box>().Moving(dir);
    }


    public void Moving(Direction direction)
    {
        var game = GameController.instance;
        int count = 0;
        Debug.Log(direction);
        switch (direction)
        {
            case Direction.Left:
                while (game.data[posx, posy - 1] != 2 && game.data[posx, posy - 1] != 4
                    && game.data[posx, posy - 1] != 1 )
                {
                    game.data[posx, posy] = 3;
                    posy = posy - 1;
                    count++;
                }
                float Xleft = rectTransform.anchoredPosition.x - (count * framelength);
                Vector2 targetLeft = new Vector2(Xleft, rectTransform.anchoredPosition.y);
                StartCoroutine(MoveObject(targetLeft));
                game.data[posx, posy] = 0;
                break;
            case Direction.Right:
                while (game.data[posx, posy + 1] != 2 && game.data[posx, posy + 1] != 4
                    && game.data[posx, posy + 1] != 1)
                {
                    game.data[posx, posy] = 3;
                    posy++;
                    count++;

                }
                float XRight = rectTransform.anchoredPosition.x + (count * framelength);
                Vector2 targetRight = new Vector2(XRight, rectTransform.anchoredPosition.y);
                StartCoroutine(MoveObject(targetRight));
                game.data[posx, posy] = 0;
                break;
            case Direction.Up:
                while (game.data[posx - 1, posy] != 2 && game.data[posx - 1, posy] != 4
                    && game.data[posx - 1, posy] != 1 )
                {
                    game.data[posx, posy] = 3;
                    posx--;
                    count++;

                }

                float Yup = rectTransform.anchoredPosition.y + (count * framelength);
                Vector2 targetUp = new Vector2(rectTransform.anchoredPosition.x, Yup);
                StartCoroutine(MoveObject(targetUp));
                game.data[posx, posy] = 0;
                break;
            case Direction.Down:
                while (game.data[posx + 1, posy] != 2 && game.data[posx + 1, posy] != 4)
                {
                    game.data[posx, posy] = 3;
                    posx++;
                    count++;

                }

                float Ydown = rectTransform.anchoredPosition.y - (count * framelength);
                Vector2 targetDown = new Vector2(rectTransform.anchoredPosition.x, Ydown);
                StartCoroutine(MoveObject(targetDown));
                game.data[posx, posy] = 0;
                break;
        }
    }

    IEnumerator MoveObject(Vector2 targetPosition)
    {
        
        while (Vector2.Distance(rectTransform.anchoredPosition, targetPosition) > 0.01)
        {

            rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;

        }
    }


}
