﻿using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_10_Check_Subtree
{
	// Time complexity: O(n + k*m)
	// Space complexity: O(log(n) + log(m))
	// n 與 m 是 T1 與 T2 的節點數量 
	// k 為 呼叫 MatchTree 的次數
	public class Q4_10_Check_SubtreeB : Question
    {
		public static bool ContainsTreeB(TreeNode t1, TreeNode t2)
		{
			if (t2 == null)
			{
				return true; // The empty tree is a subtree of every tree.
			}
			return SubTree(t1, t2);
		}

		/* Checks if the binary tree rooted at r1 contains the binary tree 
		 * rooted at r2 as a subtree somewhere within it.
		 */
		public static bool SubTree(TreeNode r1, TreeNode r2)
		{
			if (r1 == null)
			{
				return false; // big tree empty & subtree still not found.
			}
			else if (r1.Data == r2.Data && MatchTree(r1, r2))
			{
				return true;
			}
			return SubTree(r1.Left, r2) || SubTree(r1.Left, r2);
		}

		/* Checks if the binary tree rooted at r1 contains the 
		 * binary tree rooted at r2 as a subtree starting at r1.
		 */
		public static bool MatchTree(TreeNode r1, TreeNode r2)
		{
			if (r1 == null && r2 == null)
			{
				return true; // nothing left in the subtree
			}
			else if (r1 == null || r2 == null)
			{
				return false; // exactly one tree is empty, therefore trees don't match
			}
			else if (r1.Data != r2.Data)
			{
				return false;  // data doesn't match
			}
			else
			{
				return MatchTree(r1.Left, r2.Left) && MatchTree(r1.Right, r2.Right);
			}
		}



		public override void Run()
        {
			// t2 is a subtree of t1
			int[] array1 = { 1, 2, 1, 3, 1, 1, 5 };
			int[] array2 = { 2, 3, 1 };

			TreeNode t1 = AssortedMethods.CreateTreeFromArray(array1);
			TreeNode t2 = AssortedMethods.CreateTreeFromArray(array2);

			if (ContainsTreeB(t1, t2))
			{
				Console.WriteLine("t2 is a subtree of t1");
			}
			else
			{
				Console.WriteLine("t2 is not a subtree of t1");
			}

			// t4 is not a subtree of t3
			int[] array3 = { 1, 2, 3 };
			TreeNode t3 = AssortedMethods.CreateTreeFromArray(array1);
			TreeNode t4 = AssortedMethods.CreateTreeFromArray(array3);

			if (ContainsTreeB(t3, t4))
			{
				Console.WriteLine("t4 is a subtree of t3");
			}
			else
			{
				Console.WriteLine("t4 is not a subtree of t3");
			}
		}
    }
}
