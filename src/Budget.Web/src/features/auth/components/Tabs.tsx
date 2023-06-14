import { MDBTabs, MDBTabsItem, MDBTabsLink } from "mdb-react-ui-kit";

export const LoginTabId: string = "login";
export const RegisterTabId: string = "register";

interface ITabsProps {
    handleTabClick: (tabId: string) => void;
    activeTabId: string;
}

const Tabs: React.FC<ITabsProps> = (props) => (
    <MDBTabs pills justify className='mb-3 d-flex flex-row justify-content-between'>
        <MDBTabsItem>
            <MDBTabsLink onClick={() => props.handleTabClick(LoginTabId)} active={props.activeTabId === LoginTabId}>
                Login
            </MDBTabsLink>
        </MDBTabsItem>
        <MDBTabsItem>
            <MDBTabsLink onClick={() => props.handleTabClick(RegisterTabId)} active={props.activeTabId === RegisterTabId}>
                Register
            </MDBTabsLink>
        </MDBTabsItem>
    </MDBTabs>
);

export default Tabs;