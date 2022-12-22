using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public static void Reload()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}

