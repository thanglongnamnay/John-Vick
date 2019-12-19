using System;
using UnityEngine;

public class Skill {
	public abstract SkillType type { get; }
	public abstract void use();
	protected abstract void affect();
}	
