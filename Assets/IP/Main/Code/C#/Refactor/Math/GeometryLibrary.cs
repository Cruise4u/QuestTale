using System;
using UnityEngine;



public class MathLibrary
{
	public Quaternion GetRotation(Vector3 normalizedVector)
	{
		float angle = GetAngle(normalizedVector);
		Quaternion newRotation = Quaternion.Euler(0.0f, angle, 0.0f);
		return newRotation;
	}

	public float GetAngle(Vector3 point)
	{
		float angle = (Mathf.Atan2(point.x, point.z) / Mathf.PI) * 180f;
		if (angle < 0.0f)
		{
			angle += 360f;
		}
		return angle;
	}
}


public class GeometryLibrary
{
	/// Determines whether point P is inside the triangle ABC
	public bool PointInTriangle(Point A, Point B, Point C, Point P)
	{
		double s1 = C.y - A.y;
		double s2 = C.x - A.x;
		double s3 = B.y - A.y;
		double s4 = P.y - A.y;

		double w1 = (A.x * s1 + s4 * s2 - P.x * s1) / (s3 * s2 - (B.x - A.x) * s1);
		double w2 = (s4 - w1 * s3) / s1;
		return w1 >= 0 && w2 >= 0 && (w1 + w2) <= 1;
	}

	public bool PointInTriangle(Point[] points,Point insidePoint)
	{
		//Point[0] -> Point A 
		//Point[1] -> Point B 
		//Point[2] -> Point C 
		double s1 = points[2].y - points[0].y;
		double s2 = points[2].x - points[0].x;
		double s3 = points[1].y - points[0].y;
		double s4 = insidePoint.y - points[0].y;

		double w1 = (points[0].x * s1 + s4 * s2 - insidePoint.x * s1) / (s3 * s2 - (points[1].x - points[0].x) * s1);
		double w2 = (s4 - w1 * s3) / s1;
		return w1 >= 0 && w2 >= 0 && (w1 + w2) <= 1;
	}

}


public struct Point
{
	public readonly double x;
	public readonly double y;

	public Point(double x, double y)
	{
		this.x = x;
		this.y = y;
	}
}
