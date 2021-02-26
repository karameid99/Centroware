"use strict";
var KTWizard2 = function () {
  var t, e, i, r = [];
  return {
    init: function () {
      t = KTUtil.getById("kt_wizard"),
        e = KTUtil.getById("kt_form"),
        (i = new KTWizard(t, {
          startStep: 1,
          clickableSteps: !1
        })).on("change", (function (t) {
          if (!(t.getStep() > t.getNewStep())) {
            var e = r[t.getStep() - 1];
            return e && e.validate().then((function (e) {
              "Valid" == e ? (t.goTo(t.getNewStep()),
                KTUtil.scrollTop()) : Swal.fire({
                  text: "Sorry, looks like there are some errors detected, please try again.",
                  icon: "error",
                  buttonsStyling: !1,
                  confirmButtonText: "Ok, got it!",
                  customClass: {
                    confirmButton: "btn font-weight-bold btn-light"
                  }
                }).then((function () {
                  KTUtil.scrollTop()
                }
                ))
            }
            )),
              !1
          }
        }
        )),
        i.on("changed", (function (t) {
          KTUtil.scrollTop()
        }
        )),
        i.on("submit", (function (t) {

          Swal.fire({
            text: "All is good! Please confirm the form submission.",
            icon: "success",
            showCancelButton: !0,
            buttonsStyling: !1,
            confirmButtonText: "Yes, submit!",
            cancelButtonText: "No, cancel",
            customClass: {
              confirmButton: "btn font-weight-bold btn-primary",
              cancelButton: "btn font-weight-bold btn-default"
            }
          }).then((function (t) {
            t.value ? e.submit() : "cancel" === t.dismiss && Swal.fire({
              text: "Your form has not been submitted!.",
              icon: "error",
              buttonsStyling: !1,
              confirmButtonText: "Ok, got it!",
              customClass: {
                confirmButton: "btn font-weight-bold btn-primary"
              }
            })
          }
          ))

        }
        )),
        r.push(FormValidation.formValidation(e, {
          fields: {
            'property[owner_id]': {
              validators: {
                notEmpty: {
                  message: "Owner is required"
                }
              }
            },
            'property[property_id]': {
              validators: {
                notEmpty: {
                  message: "Property is required"
                }
              }
            },
            'property[unit_id]': {
              validators: {
                notEmpty: {
                  message: "Unit is required"
                }
              }
            },
          },
          plugins: {
            trigger: new FormValidation.plugins.Trigger,
            bootstrap: new FormValidation.plugins.Bootstrap({
              eleValidClass: ""
            })
          }
        })),
        r.push(FormValidation.formValidation(e, {
          fields: {
            'property[tenant_id]': {
              validators: {
                notEmpty: {
                  message: "Tenant is required"
                }
              }
            },
            'contract[agreement_period]': {
              validators: {
                notEmpty: {
                  message: "Agreement period is required"
                }
              }
            },
          },
          plugins: {
            trigger: new FormValidation.plugins.Trigger,
            bootstrap: new FormValidation.plugins.Bootstrap({
              eleValidClass: ""
            })
          }
        }))
        
    }
  }
}();

jQuery(document).ready((function () {
  KTWizard2.init()
}
));