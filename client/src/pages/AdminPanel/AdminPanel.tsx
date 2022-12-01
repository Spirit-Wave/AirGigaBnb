import ApartmentApproveList from "../../components/ApartmentApprove/ApartmentsWaitingList";
import Header from "../../components/Header/Header";

function AdminPanel() {
  return (
    <>
      <Header />
      <ApartmentApproveList></ApartmentApproveList>
    </>
  );
}

export default AdminPanel;
