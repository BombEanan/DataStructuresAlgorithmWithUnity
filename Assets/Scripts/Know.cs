using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode (int x)
    {
        val = x;
    }
}
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode (int x)
    {
        val = x;
    }
}

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
 
        Debug.Log(replaceSpace("We Are Happy"));

        List<ListNode> l = new List<ListNode>();
        ListNode ln = new ListNode(0);
        int ii = 0;
        while(ii<10){
            ii++;
            ListNode ln0 = new ListNode(ii);
            l.Add(ln0);            
        }
        for(int j=0;j<l.Count-1;j++){
            
            l[j].next = l[j+1];
        }
        
        Debug.Log(printListFromTailToHead(null));

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

    public string replaceSpace(string str)
    {
        // write code here
       string s = str.Replace(" ","20%");

        return s;
    }

     // 返回从尾到头的列表值序列
    public List<int> printListFromTailToHead(ListNode listNode)
    {
        List<int> list = new List<int>();
        if(listNode==null){
            return list;
        }
        
        list.Add(listNode.val);        
        while(listNode.next!=null){
            listNode = listNode.next;
            list.Add(listNode.val);
        }
        List<int> list0 = new List<int>();
        for(int i=list.Count-1;i>=0;i--){
            list0.Add(list[i]);
        }

        return list0;
    }

    ///重构二叉树
    ///pre 前序遍历  根，左，右
    ///tin 中序遍历  左，根，右
    ///(后序遍历) 左，右，根
    public TreeNode reConstructBinaryTree(int[] pre, int[] tin)
    {

        // write code here
        return null;
    }

    public int GetLightOnCount (int count){
        
        List<bool> list = new List<bool>();
        //初始化灯
        for(int i = 0; i<count;i++){
            list.Add(false);
        }

        for(int i = 0;i<count;i++){
            for(int j = 0;j<count;j++){            

                Debug.Log("第"+i+j+"个改变了");
                list[i+j] = !list[i+j];
            }
        }

        return 0;
    }

    void EnAble(){
        Debug.Log("Enable");
    }
	// Use this for initialization
	void Start () {
        StartCoroutine(Fade());
        
        Debug.Log("亮着的剩几个："+GetLightOnCount(4));
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
