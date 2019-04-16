/**
 * Copyright (c) 2010-2015, WyrmTale Games and Game Components
 * All rights reserved.
 *
 * THIS SOFTWARE IS PROVIDED BY WYRMTALE GAMES AND GAME COMPONENTS 'AS IS' AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL WYRMTALE GAMES AND GAME COMPONENTS BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */ 
using UnityEngine;
using System.Collections;

// Die subclass to expose the D20 side hitVectors
public class Die_d20 : Die
{

    override protected Vector3 HitVector(int side)
    {
        switch (side)
        {
            case 1: return new Vector3(0F, -0.97F, 0.2F);
            case 2: return new Vector3(0F, 0.59F, -0.80F);
            case 3: return new Vector3(0.55F, -0.19F, 0.79F);
            case 4: return new Vector3(-0.90F, 0.35F, -0.17F);
            case 5: return new Vector3(-0.29F, -0.55F, -0.75F);
            case 6: return new Vector3(-0.35F, 0.48F, 0.79F);
            case 7: return new Vector3(0.55F, -0.75F, -0.17F);
            case 8: return new Vector3(0.60F, 0.77F, 0.16F);
            case 9: return new Vector3(-0.55F, -0.15F, 0.75F);
            case 10: return new Vector3(0.90F, 0.35F, -0.14F);
            case 11: return new Vector3(-0.90F, -0.35F, 0.21F);
            case 12: return new Vector3(0.62F, 0.16F, -0.765F);
            case 13: return new Vector3(-0.55F, -0.83F, -0.13F);
            case 14: return new Vector3(-0.55F, 0.81F, 0.15F);
            case 15: return new Vector3(0.42F, -0.46F, -0.75F);
            case 16: return new Vector3(0.35F, 0.48F, 0.80F);
            case 17: return new Vector3(0.94F, -0.29F, 0.14F);
            case 18: return new Vector3(-0.55F, 0.15F, -0.81F);
            case 19: return new Vector3(0F, -0.55F, 0.81F);
            case 20: return new Vector3(0F, 1F, -0.2F);
        }
        return Vector3.zero;
    }
}