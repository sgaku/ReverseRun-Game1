using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainStage : MonoBehaviour
{
    
    const int StageTipSize = 1000;
    
    int currentTipIndex;
  
    public Transform character;
    
    public GameObject[] stageTips;
  
    public int startTipIndex;
    
    public int preInstantiate;
  
    public List<GameObject> generatedStageList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        currentTipIndex = startTipIndex - 1;
        UpdateStage(preInstantiate);
    }

    // Update is called once per frame
    void Update()
    {
  
        int charaPositionIndex = (int)(character.position.z / StageTipSize);
     
        if (character.position != null && charaPositionIndex + preInstantiate > currentTipIndex)
        {
            UpdateStage(charaPositionIndex + preInstantiate);
        }
    }
    void UpdateStage(int toTipIndex)
    {
        if (toTipIndex <= currentTipIndex) return;
       
        for (int i = currentTipIndex + 1; i <= toTipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i);
           
            generatedStageList.Add(stageObject);
        }
       
        while (generatedStageList.Count > preInstantiate + 2) DestroyOldestStage();

        currentTipIndex = toTipIndex;
    }
    GameObject GenerateStage(int tipIndex) 
    {
        int nextStageTip = Random.Range(0, stageTips.Length);

        GameObject stageObject = (GameObject)Instantiate(
            stageTips[nextStageTip],
            new Vector3(-500, -20, tipIndex * StageTipSize),
            Quaternion.identity);
        return stageObject;
    }
    void DestroyOldestStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}
