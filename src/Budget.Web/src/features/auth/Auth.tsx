import React, { useState } from 'react';
import { MDBContainer } from "mdb-react-ui-kit";
import AuthTabs, { LoginTabId } from "./components/Tabs";
import AuthTabsContent from "./components/TabsContent";
import { useAppDispatch } from '../../app/hooks';

export const Auth = () => {
    const dispatch = useAppDispatch();
    const [incrementAmount, setIncrementAmount] = useState('2');

    const incrementValue = Number(incrementAmount) || 0;
    const [activeTab, setActiveTab] = useState<string>(LoginTabId);

    const handleTabClick = (id: string) => {
        if (id === activeTab) {
            return;
        }
        setActiveTab(id);
    }

    return (
        <MDBContainer className="p-3 my-5 d-flex flex-column w-50">
            <AuthTabs
                handleTabClick={handleTabClick}
                activeTabId={activeTab}
            />
            <AuthTabsContent
                activeTabId={activeTab}
            />
        </MDBContainer>
    );
}
