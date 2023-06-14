import { MDBTabsContent, MDBTabsPane } from "mdb-react-ui-kit";
import { LoginTabId, RegisterTabId } from "./Tabs";
import RegisterForm from "./RegisterForm";
import LoginForm from "./LoginForm";

interface ITabsContentProps {
    activeTabId: string;
}

const TabsContent: React.FC<ITabsContentProps> = props => {
    const { activeTabId } = props;

    return (
        <MDBTabsContent>
            <MDBTabsPane show={activeTabId === LoginTabId}>
                <LoginForm />
            </MDBTabsPane>
            <MDBTabsPane show={activeTabId === RegisterTabId}>
                <RegisterForm />
            </MDBTabsPane>
        </MDBTabsContent>
    );
};

export default TabsContent;