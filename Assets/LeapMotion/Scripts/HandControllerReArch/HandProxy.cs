﻿using UnityEngine;
using System.Collections;

namespace Leap {
  public class HandProxy:
    HandRepresentation
  {
    HandPool parent;

  
    public HandProxy(HandPool parent, HandModel handModel, Leap.Hand hand) :
      base(hand.Id)
    {
      this.parent = parent;
      this.handModel = handModel;
      handModel.SetLeapHand(hand);
      handModel.InitHand();
      Debug.Log("handProxy Constructor ------------------------------");
    }

    public override void Finish() {
      Debug.Log("HandProxy Finishing");
      parent.ModelPool.Add(handModel);
      handModel = null;
    }

    public override void UpdateRepresentation(Leap.Hand hand, HandModel.ModelType modelType){
      // TODO:  Decide how to pass information about the updated hand to the hand model
      handModel.SetLeapHand(hand);
      handModel.UpdateHand();
    }
  }
}
