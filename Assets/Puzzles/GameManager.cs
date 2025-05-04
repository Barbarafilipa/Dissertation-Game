using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform gameTransform;
    [SerializeField] private Transform piecePrefab;

    [SerializeField] private MinigameManager minigameManager;
    [SerializeField] private Sprite emotionSprite;

    private List<Transform> pieces;
    private int size;
    private bool shuffling = false;

    // Create the game setup with size x size pieces
    private void CreateGamePieces(float gapThickness)
    {
        // This is the width of each tile
        float pieceSize = 250f;
        float gap = gapThickness * pieceSize;

        float totalWidth = size * pieceSize;
        float totalHeight = size * pieceSize;

        float xOffset = -totalWidth / 2f;
        float yOffset = totalHeight / 2f;

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                Transform piece = Instantiate(piecePrefab, gameTransform);
                // Set the piece material to the emotion sprite
                piece.GetComponent<RawImage>().texture = emotionSprite.texture;
                pieces.Add(piece);

                RectTransform rt = piece.GetComponent<RectTransform>();
                rt.sizeDelta = new Vector2(pieceSize - gap, pieceSize - gap);

                // Anchor pivot to top-left (0, 1) for grid-like positioning
                rt.anchorMin = new Vector2(0, 1);
                rt.anchorMax = new Vector2(0, 1);
                rt.pivot = new Vector2(0, 1);

                // Set anchored position in grid layout
                rt.anchoredPosition = new Vector2(col * pieceSize, -row * pieceSize);

                piece.name = $"{(row * size) + col}";

                // Setup UV cropping (same as UVs but now with uvRect)
                RawImage rawImage = piece.GetComponent<RawImage>();

                float uvWidth = 1f / size;
                float uvHeight = 1f / size;

                float u = col * uvWidth;
                float v = 1f - ((row + 1) * uvHeight); // Flip Y axis

                rawImage.uvRect = new Rect(u, v, uvWidth, uvHeight);
            }
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pieces = new List<Transform>();
        size = 3;

        // Check for completion
        if (!shuffling && CheckCompletion())
        {
            shuffling = true;
            StartCoroutine(WaitShuffle(0.5f));
        }

        CreateGamePieces(0.01f); 
    }

    public void SwapPieces(Piece a, Piece b)
    {
        // Swap references in the list
        int indexA = pieces.IndexOf(a.transform);
        int indexB = pieces.IndexOf(b.transform);

        if (indexA != -1 && indexB != -1)
        {
            Transform temp = pieces[indexA];
            pieces[indexA] = pieces[indexB];
            pieces[indexB] = temp;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (!shuffling && CheckCompletion()) {
            // Wait 2 seconds before completing the minigame
            StartCoroutine(WaitComplete(2f));
            //minigameManager.CompleteMinigame();
        }
    }

    private IEnumerator WaitComplete(float duration)
    {
        yield return new WaitForSeconds(duration);
        minigameManager.CompleteMinigame();
    }

    private bool CheckCompletion()
    {
        for (int i=0; i<pieces.Count; i++)
        {
            if (pieces[i].name != $"{i}") {
                return false;
            }
        }

        return true;
    }

    private IEnumerator WaitShuffle(float duration)
    {
        yield return new WaitForSeconds(duration);
        Shuffle();
        shuffling = false;
    }

    // Brute force shuffling
    private void Shuffle()
    {
        int total = pieces.Count;

        // Fisher–Yates shuffle algorithm (efficient and fair)
        for (int i = total - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1); // Pick a random index up to i

            // Swap their positions
            Vector3 tempPos = pieces[i].localPosition;
            pieces[i].localPosition = pieces[j].localPosition;
            pieces[j].localPosition = tempPos;

            // Also swap their references in the list to keep it consistent
            Transform temp = pieces[i];
            pieces[i] = pieces[j];
            pieces[j] = temp;
        }
    }

}
