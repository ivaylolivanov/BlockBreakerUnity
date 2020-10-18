using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] public AudioClip hitSound;
    [SerializeField] public GameObject destroyBlockVFX;
    [SerializeField] public Sprite[] hitSprites;
    [SerializeField] public Color[] hitSpriteColors;

    // Cached references
    private Level level;
    private GameStatus gameStatus;

    // State variables
    private int hits;
    [SerializeField] private int maxHits;

    private void Start() {
        CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatus>();

        maxHits = hitSprites.Length + 1;
        if(tag == "Solid") {
            maxHits = hitSpriteColors.Length + 1;
        }

    }

    private void CountBreakableBlocks() {
        level = FindObjectOfType<Level>();
        if(tag == "Breakable") {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(tag == "Breakable" || tag == "Solid") {
            HandleHit();
        }
    }

    private void HandleHit() {
        ++hits;
        PlayHitSound();
        if(hits >= maxHits) {
            DestroyBlock();
        }
        else {
            ShowDamage(hits - 1);
        }
    }

    private void ShowDamage(int index) {
        if(tag == "Breakable") {
            ShowHitSprite(index);
        }
        else if(tag == "Solid") {
            ChangeSpriteColor(index);
        }
    }

    private void ShowHitSprite(int index) {
        if(hitSprites[index] != null) {
            GetComponent<SpriteRenderer>().sprite = hitSprites[index];
        }
        else {
            Debug.LogError("Block hit sprite missing - " + gameObject.name );
        }
    }

    private void ChangeSpriteColor(int index) {
        if(hitSpriteColors[index] != null) {
            GetComponent<SpriteRenderer>().color = hitSpriteColors[index];
        }
        else {
            Debug.LogError("Block hit color is missing - " + gameObject.name);
        }
    }

    private void DestroyBlock() {
        level.DestroyBlock();
        gameStatus.AddToScore();

        TriggerDestroyBlockVFX();
        Destroy(gameObject);
    }

    private void PlayHitSound() {
        Vector3 mainCameraPosition = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(hitSound, mainCameraPosition);
    }

    private void TriggerDestroyBlockVFX() {
        GameObject destroyVFX = Instantiate(destroyBlockVFX, transform.position, transform.rotation);
        Destroy(destroyVFX, 1f);
    }
}
