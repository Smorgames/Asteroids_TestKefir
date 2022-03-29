using View;

namespace Logic.Meteor
{
    public class MeteorController
    {
        private readonly MeteorModel _meteorModel;
        private readonly MeteorView _meteorView;

        public MeteorController(MeteorModel meteorModel, MeteorView meteorView)
        {
            _meteorModel = meteorModel;
            _meteorView = meteorView;

            SubscribeOnEvents();
        }

        private void SubscribeOnEvents()
        {
            _meteorView.OnMoveRequest += ViewMoveRequest;
            _meteorModel.Transform.OnPositionChanged += ModelPositionChanged;
        }

        private void ViewMoveRequest(float deltaTime) => 
            _meteorModel.Move(deltaTime);

        private void ModelPositionChanged() => 
            _meteorView.SetPosition(_meteorModel.Transform.Position);
    }
}