import { MDBBtn, MDBInput } from "mdb-react-ui-kit";
import { useImmer } from "use-immer";
import { useAppDispatch } from "../../../app/hooks";
import { loginAsync } from "../authSlice";

const formId: string = "loginForm"

const LoginForm = () => {
    const dispatch = useAppDispatch();
    const [state, setState] = useImmer({
        password: "",
        username: "",
    });

    const handleLogin = () => {
        dispatch(loginAsync({ ...state }));
    };

    return (
        <>
            <MDBInput
                wrapperClass="mb-4"
                label="Username"
                id={formId}
                type="text"
                value={state.username}
                onChange={e => setState(draft => { draft.username = e.target.value; })}
            />
            <MDBInput
                wrapperClass="mb-4"
                label="Password"
                id={formId}
                type="password"
                value={state.password}
                onChange={e => setState(draft => { draft.password = e.target.value; })}
            />

            <MDBBtn
                onClick={handleLogin}
                className="mb-4 w-100"
            >
                Sign in
            </MDBBtn>
        </>
    );
};

export default LoginForm;