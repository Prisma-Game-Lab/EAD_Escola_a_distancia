using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool findDistance = false;
    [SerializeField]
    private int linhas = 10;
    [SerializeField]
    private int colunas = 10;
    private int scale = 1;
    [SerializeField]
    private GameObject gridPrefab;
    [SerializeField]
    private GameObject player;
    private Vector3 leftBottomLocation = new Vector3(0,0,0);
    private GameObject[,] gridArray;
    [SerializeField]
    public int startX = 0;
    [SerializeField]
    public int startY = 0;
    [SerializeField]
    public int endX = 2;
    [SerializeField]
    public int endY = 2;
    public List<GameObject> path =  new List<GameObject>();

    void Awake()
    {
        // cria o vetor Linhas x Colunas
        gridArray = new GameObject[colunas,linhas];
        //Popula o vetor com os GameObjects gridprefab
        GenerateGrid();
    }

    void Update()
    {
        if(findDistance)
        {
            SetDistance();
            SetPath();
            findDistance = false;
        }
    }

    //Popula o vetor com os GameObjects gridprefab
    void GenerateGrid()
    {
        for(int i = 0; i < colunas; i++)
        {
            for(int j = 0; j < linhas; j++)
            {
                GameObject obj = Instantiate(gridPrefab,new Vector3 (leftBottomLocation.x + scale * i, leftBottomLocation.y,leftBottomLocation.z + scale * j), Quaternion.identity);
                obj.transform.SetParent(gameObject.transform);
                obj.GetComponent<GridStat>().x = i;
                obj.GetComponent<GridStat>().y = j ;
                gridArray[i,j] = obj;
            }
        }
    }

    void SetDistance()
    {
        InitialSetUp();
        int x = startX;
        int y = startY;
        for (int step = 1; step < linhas*colunas; step++)
        {
            foreach (GameObject obj in gridArray)
            {
                if (obj && obj.GetComponent<GridStat>().visited == step-1)
                    TestFourDirections(obj.GetComponent<GridStat>().x,obj.GetComponent<GridStat>().y, step);
            }
        }
    }

    void SetPath()
    {
        int step;
        int x = endX;
        int y = endY;
        List<GameObject> tempList = new List<GameObject>();
        path.Clear();
        if (gridArray[endX,endY] && gridArray[endX,endY].GetComponent<GridStat>().visited > 0)
        {
            path.Add(gridArray[x,y]);
                step = gridArray[x,y].GetComponent<GridStat>().visited -1;
        }
        else
        {
            return;
        }
        for (int i = step; step > -1; step--)
        {
            if (TestDirection(x,y,step,1))
                tempList.Add(gridArray[x,y+1]);
            if (TestDirection(x,y,step,2))
                tempList.Add(gridArray[x+1,y]);
            if (TestDirection(x,y,step,3))
                tempList.Add(gridArray[x,y-1]);
            if (TestDirection(x,y,step,4))
                tempList.Add(gridArray[x-1,y]);

            GameObject tempObj = FindClosest(gridArray[endX,endY].transform, tempList);
            path.Add(tempObj);
            x = tempObj.GetComponent<GridStat>().x;
            y = tempObj.GetComponent<GridStat>().y;
            tempList.Clear();
        }
    }

    // zera a grid para um novo caminho
    void InitialSetUp()
    {
        foreach (GameObject obj in gridArray)
        {
            obj.GetComponent<GridStat>().visited = -1;
        }
        gridArray[startX, startY].GetComponent<GridStat>().visited = 0;
    }

    //Confere se uma direcao existe se ja esta marcada
    bool TestDirection(int x, int y, int step, int direction)
    {
        switch(direction)
        {
            case 4:
                if(x-1 > -1 && gridArray[x-1,y] && gridArray[x-1,y].GetComponent<GridStat>().visited == step)
                    return true;
                else
                    return false;
            case 3:
                if(y-1 > -1 && gridArray[x,y-1] && gridArray[x,y-1].GetComponent<GridStat>().visited == step)
                    return true;
                else
                    return false;
            case 2:
                if(x+1 < colunas && gridArray[x+1,y] && gridArray[x+1,y].GetComponent<GridStat>().visited == step)
                    return true;
                else
                    return false;
            case 1:
                if(y+1 < linhas && gridArray[x,y+1] && gridArray[x,y+1].GetComponent<GridStat>().visited == step)
                    return true;
                else
                    return false;
        }
        return false;
    }

    // marca as 4 direcoes vizinhas
    void TestFourDirections(int x, int y, int step)
    {
        if (TestDirection(x,y,-1,1))
            SetVisited(x,y+1,step);

        if (TestDirection(x,y,-1,2))
            SetVisited(x+1,y,step);

        if (TestDirection(x,y,-1,3))
            SetVisited(x,y-1,step);

        if (TestDirection(x,y,-1,4))
            SetVisited(x-1,y,step);
    }

    // marca um quadrado determinado
    void SetVisited (int x, int y, int step)
    {
        if (gridArray[x,y])
            gridArray[x,y].GetComponent<GridStat>().visited = step;
    }

    // encontra o tile mais proximo
    GameObject FindClosest(Transform targetLocation, List<GameObject> list)
    {
        float currentDistance = scale * linhas * colunas;
        int indexNumber = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (Vector3.Distance(targetLocation.position, list[i].transform.position) < currentDistance)
            {
                currentDistance = Vector3.Distance(targetLocation.position, list[i].transform.position);
                indexNumber = i;
            }
        }
        return list[indexNumber];
    }

    public List<GameObject> GetPath()
    {
        SetDistance();
        SetPath();
        findDistance = false;
        return path;
    }
}