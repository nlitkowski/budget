import { MDBBtn, MDBInput, MDBCheckbox } from "mdb-react-ui-kit";

interface IRegisterFormProps {

}

const formId: string = "registerForm"

const RegisterForm: React.FC<IRegisterFormProps> = props => {
    return (
        <>
            <MDBInput wrapperClass="mb-4" label="Username" id={formId} type="text" />
            <MDBInput wrapperClass="mb-4" label="Email" id={formId} type="email" />
            <MDBInput wrapperClass="mb-4" label="Password" id={formId} type="password" />

            <MDBBtn className="mb-4 w-100">Sign up</MDBBtn>
        </>
    );
};

export default RegisterForm;