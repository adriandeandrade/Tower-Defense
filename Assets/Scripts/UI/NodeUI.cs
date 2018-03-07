using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private UIManager uiManager;
    private Node target; // Note: This is the node that we want the UI to appear over [may change in the future].

    [SerializeField] private Text upgradeCost;
    [SerializeField] private Text sellAmount;
    [SerializeField] private Button upgradeButton;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        Hide();
    }

    // Note: This function sets all the attributes based on what turret is on the target node.
    public void InitializeTarget(Node target)
    {
        this.target = target;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded) // Here we check if the turret on the target node is upgraded.
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
        uiManager.Activate("nodePanel");
    }

    public void Hide()
    {
        uiManager.Deactivate("nodePanel");
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

}
