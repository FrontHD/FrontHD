local Object = game.Part
local TweenService = game:GetService("TweenService")
local Tweeninfo = TweenInfo.new(Enum.EasingStyle.Sine,Enum.EasingDirection.InOut,0,false,0)
local Goal1 = {Position = Vector3.new(1,0,0)}
local Goal2 = {Position = Vector3.new(0,0,0)}
local PlayGoal1 = TweenService:Create(Object,TweenInfo,Goal1)
local PlayGoal2 = TweenService:Create(Object,TweenInfo,Goal2)