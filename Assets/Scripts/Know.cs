using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Know : MonoBehaviour {

   public GameObject go;

    void Reset(){
        Debug.Log("Reset");
    }
    void Awake(){
        Debug.Log("Awake");

        //4^0+4^1+4^2
        decimal totel = 1;
        for(int i = 1;i<0;i++){
            decimal mi = 1;
            for(int j = 0;j<i;j++){
                mi*=4;
            }
            totel+=mi;
            mi=1;
        }
        //Debug.Log("totel:"+totel);

        int[][] a = new int[3][] ;
        a[0] = new int [5]{1,2,3,4,5};
        a[1] = new int [3]{6,7,8};
        a[2] = new int [4]{9,10,11,12};

        int [][] b = new int[0][] ;

        Debug.Log(Find(7,b) );
 
        

    }

    //遍历二维数组中是否含有某个整数
    public bool Find(int target, int[][] array)
    {
        // write code here
        for(int i=0;i<array.Length;i++){
            for(int j=0;j<array[i].Length;j++){
                if(array[i][j] == target){
                    Debug.Log(array[i][j]);
                    return true;
                }
            }
        }
        return false;
    }

    void EnAble(){
        Debug.Log("Enable");
    }
	// Use this for initialization
	void Start () {
        StartCoroutine(Fade());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //协程就是协同程序，在主线程运行是开启另一段逻辑处理，来协助当前程序的执行，
    //协程很像多线程，但不是多线程，
    //unity的协程是在每帧结束后去检测yield的条件是否满足。

    //yield 关键字向编译器指示它所在的方法是迭代器块。yield 关键字与return和break一起使用
    // yield return <expression>;
    // yield break;
    // 在yield return 语句中，将计算expression并将结果以值的形式返回给枚举器对象；expression 必须可以隐式转换为yield类型的迭代器
     
    //物体渐渐消失
    IEnumerator Fade()
    {
        Color c = this.go.GetComponent<Renderer>().material.color;
        for (float a = 1f; a >= 0; a-=0.01f)
        {
            
            c.a = a;
            //Debug.Log(a);
            this.go.GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(0.1f);
        }

        while(true){
            
            yield return new WaitForSeconds(0.02f);   
        }
    }

}
